import { Component, OnInit } from '@angular/core';
import { UrlShortenerService } from '../services/url-shortener-service';

@Component({
  selector: 'app-url-shortener',
  templateUrl: './url-shortener.component.html',
  styleUrls: ['./url-shortener.component.scss']
})
export class UrlShortenerComponent implements OnInit {
    newUrl: string = '';
    shortenedUrl: string = '';
    shortenedUrls: string[] = [];

    constructor(private urlShortenerService: UrlShortenerService) {
        
    }
    ngOnInit(): void {
        this.loadUrls();
    }

    onShortenButtonClick() {
        this.urlShortenerService.addShortenedUrl(this.newUrl)
            .subscribe({
                next: url => {
                    this.shortenedUrl = url;
                    this.shortenedUrls.push(url);
                    this.newUrl = "";
                }
            });
    }

    loadUrls() {
        this.urlShortenerService.getUrls()
            .subscribe({
                next: urls => {
                    this.shortenedUrls = urls;
                }
            });
    }
}
