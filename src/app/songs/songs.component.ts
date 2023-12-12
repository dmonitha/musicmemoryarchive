import { Component } from '@angular/core';
import { Song } from './song';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent {

  public songData: Song[] = [];
  constructor(http: HttpClient) {
    http.get<Song[]>(environment.baseUrl + 'api/song').subscribe
    ({
      next : result => {
      this.songData = result;
    }, 
    error:error => {console.error(error)}
   } );
  }

}
