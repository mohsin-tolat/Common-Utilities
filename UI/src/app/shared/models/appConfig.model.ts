import { environment } from 'src/environments/environment';

export const AppConfig = {
  hostingEnvironment: environment.hostingEnvironment,
  API_ENDPOINT_PREFIX: environment.ApiEndPoint,
  Environment_Config: {
    Production: environment.production,
  },
};

export const UrlConfig = {
  GET_ENCRYPTED_TEXT:
    AppConfig.API_ENDPOINT_PREFIX + 'api/Encryption/GetEncryptedValue',
  GET_DECRYPTED_TEXT:
    AppConfig.API_ENDPOINT_PREFIX + 'api/Encryption/GetDecryptedValue',
};
