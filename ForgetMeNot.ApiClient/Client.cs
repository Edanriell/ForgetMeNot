using RestSharp;
using ForgetMeNot.Api.Domain;
using RestSharp.Authenticators.OAuth2;
using ForgetMeNot.Api.Dto;

namespace ForgetMeNot.ApiClient
{
    public class Client
    {
        RestClient? client;

        string baseUrl;
        string? username;
        string? password;

        public Client(string baseUrl)
        {
            this.baseUrl = baseUrl;

            SetClient();
        }

        void SetClient()
        {
            var options = new RestClientOptions(baseUrl)
            {
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };

            client = new RestClient(options);
        }

        #region Auth

        public bool IsAuthenticated => client?.Authenticator != null;

        public async Task Login(LoginRequest request)
        {
            username = request.Username;
            password = request.Password;

            await Authenticate();
        }

        public Task CreateAccount(AccountCreateRequest accountCreateRequest)
        {
            var request = new RestRequest("auth/createaccount");
            request.AddBody(accountCreateRequest);

            return client!.PostAsync<string>(request);
        }

        async Task Authenticate()
        {
            var request = new RestRequest("auth/gettoken");
            request.AddBody(new { username, password });

            var accessToken = await client!.PostAsync<string>(request);

            client!.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                accessToken!,
                "Bearer"
            );
        }

        #endregion

        #region Util

        public Task<string?> Version()
        {
            var request = new RestRequest("util/version");

            return client!.GetAsync<string?>(request);
        }

        #endregion

        #region Profile

        public Task<ProfileResponse?> GetProfile()
        {
            var request = new RestRequest("profile/me");

            return client!.GetAsync<ProfileResponse?>(request);
        }

        public Task UpdateProfile(ProfileUpdateRequest profileUpdateRequest)
        {
            var request = new RestRequest("profile/me");

            request.AddBody(profileUpdateRequest);

            return client!.PutAsync(request);
        }

        #endregion

        #region Buddy

        public Task<List<BuddyDto>?> GetBuddy()
        {
            var request = new RestRequest("buddy");
            return client!.GetAsync<List<BuddyDto>?>(request);
        }

        public Task<Guid?> CreateInvitation(InviteCreateRequest inviteCreateRequest)
        {
            var request = new RestRequest("buddy/invite");
            request.AddBody(inviteCreateRequest);
            return client!.PostAsync<Guid?>(request);
        }

        #endregion

        public Task<List<UserResponse>?> GetUserList()
        {
            var request = new RestRequest("user");

            return client!.GetAsync<List<UserResponse>?>(request);
        }
    }
}
