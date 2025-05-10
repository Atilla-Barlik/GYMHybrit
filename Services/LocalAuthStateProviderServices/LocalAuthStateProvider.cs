using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.LocalAuthStateProviderServices
{
    public class LocalAuthStateProvider : AuthenticationStateProvider
    {
        private const string StorageKey = "authUserId";
        private const string AuthType = "apiauth_type";
        private readonly ILocalStorageService _storage;
        private readonly ClaimsPrincipal _anonymous
            = new(new ClaimsIdentity());

        private ClaimsPrincipal _currentUser;
        private int? _currentUserId;
        public int? CurrentUserId => _currentUserId;
        public LocalAuthStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
            _currentUser = _anonymous;
            _currentUserId = 0;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            int storedId = 0;

            try
            {
                // 1) Anahtar varsa oku
                var exists = await _storage.ContainKeyAsync(StorageKey);
                if (exists)
                {
                    storedId = await _storage.GetItemAsync<int>(StorageKey);
                }
            }
            catch
            {
                // Prerender veya JS yoksa buraya düşecek:
                // Anonim döner, ama OnAfterRenderAsync'te tekrar denenecek
                return new AuthenticationState(_anonymous);
            }

            if (storedId > 0)
            {
                // 2) Geçerli bir userId bulunursa claim’leyip dön
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, storedId.ToString())
                }, AuthType);

                _currentUser = new ClaimsPrincipal(identity);
                _currentUserId = storedId;
                return new AuthenticationState(_currentUser);
            }
            _currentUserId = null;
            // 3) Hiç yoksa anonim
            return new AuthenticationState(_anonymous);
        }

        /// <summary>
        /// Giriş başarılı, dilersen kalıcı (rememberMe) sakla.
        /// </summary>
        

        public async Task MarkUserAsAuthenticated(int userId, bool rememberMe)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }, AuthType);
            _currentUser = new ClaimsPrincipal(identity);
            _currentUserId = userId;
            // 2) State’i bildir
            var state = Task.FromResult(new AuthenticationState(_currentUser));
            NotifyAuthenticationStateChanged(state);

            // 3) hatırla seçilmişse storage’a kaydet
            if (rememberMe)
                await _storage.SetItemAsync(StorageKey, userId);
        }

        /// <summary>
        /// Çıkış yapıldığında hem state’i sıfırla hem storage’dan sil.
        /// </summary>
        public async Task MarkUserAsLoggedOut()
        {
            _currentUser = _anonymous;
            _currentUserId = null;
            var anonState = Task.FromResult(new AuthenticationState(_anonymous));
            NotifyAuthenticationStateChanged(anonState);

            // 2) storage’dan sil
            await _storage.RemoveItemAsync(StorageKey);
        }
    }
}
