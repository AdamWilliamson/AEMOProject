import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Website';
  text = new FormControl('');
  subText = new FormControl('');
  caseSensitive: boolean = false;
  results: Array<number> = null;
  error: unknown = null;

  constructor(
    private http: HttpClient){}

  findMatches() {
    
    const headers = { 'content-type': 'application/json'};
    const body  = JSON.stringify({
      Text: this.text.value,
      SubText: this.subText.value,
      CaseSensitive: this.caseSensitive
    });
    
    this.http.post<any>("https://localhost:44371/SubTextMatching/FindMatches", body, {'headers': headers})
      .subscribe(data => {
        this.error = null;
        this.results = data.matchIndexes;
      }, error => {
        this.error = error.error;
        this.results = null;
      });
  }
}
