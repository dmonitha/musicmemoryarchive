import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Custom } from './custom';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CustomService {
 
  constructor(protected http: HttpClient) {


   }

   fetchData(albumId: number) : Observable<Custom[]>{
     var url = environment.baseUrl + `api/album/custom/${albumId}`;
    return this.http.get<Custom[]>(url);

   }
}

