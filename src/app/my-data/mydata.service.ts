import { Injectable } from '@angular/core';
import { Song } from '../songs/song';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MydataService {
  constructor(protected http : HttpClient) { }


  onCheckMethod(songData : Song)  : Observable<Song>{
    var url = environment.baseUrl + 'api/Song';
    console.log(" the url",url);
    return this.http.post<any>(url,songData);
    
  }
}
