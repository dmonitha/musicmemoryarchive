import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Album } from './album';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent {

  public albumdata: Album[] = [];
  
  //, @Inject('BASE_URL') baseUrl: string
  constructor(http: HttpClient) {
    http.get<Album[]>(environment.baseUrl + 'api/album').subscribe
    ({
      next : result => {
      this.albumdata = result;
    }, 
    error:error => {console.error(error)}
   } );
  }

}












