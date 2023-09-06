import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'OrderProject',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44338/',
    redirectUri: baseUrl,
    clientId: 'OrderProject_App',
    responseType: 'code',
    scope: 'offline_access OrderProject',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44338',
      rootNamespace: 'OrderProject',
    },
  },
} as Environment;
