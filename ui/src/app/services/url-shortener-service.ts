import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UrlShortenerService {
    // Should me moved to Constants class
    private readonly baseUrl: string = 'https://localhost:44340/UrlShortener/';

	constructor(private httpClient: HttpClient) { }
    
	getUrl(shortenUrl: string): Observable<string> {
        const requestUrl: string = `${this.baseUrl}${shortenUrl}`;
		return this.httpClient
			.get<string>(requestUrl);
	}

    getUrls(): Observable<string[]> {
        const requestUrl: string = this.baseUrl;
		return this.httpClient
			.get<string[]>(requestUrl);
    }

    addShortenedUrl(newUrl: string): Observable<string> {
        const requestUrl: string = this.baseUrl;
        return this.httpClient
			.post<string>(requestUrl, {url: newUrl});
    }
}
