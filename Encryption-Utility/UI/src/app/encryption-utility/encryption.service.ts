import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlConfig } from '../shared/models/appConfig.model';
import { ApiOutput } from '../shared/models/apiOutput.model';

@Injectable()
export class EncryptionService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private httpClient: HttpClient) {}

  public GetEncryptedText(plainText: string): Observable<ApiOutput<string>> {
    const url = UrlConfig.GET_ENCRYPTED_TEXT + '?plainText=' + plainText;
    return this.httpClient.get<ApiOutput<string>>(url, this.httpOptions);
  }

  public GetDecryptedText(
    encryptedText: string
  ): Observable<ApiOutput<string>> {
    const url =
      UrlConfig.GET_DECRYPTED_TEXT + '?encryptedText=' + encryptedText;
    return this.httpClient.get<ApiOutput<string>>(url, this.httpOptions);
  }
}
