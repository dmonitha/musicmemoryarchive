import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Register } from './register';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(protected http: HttpClient) { }

  registerUser(userRequest: Register) : Observable<Register>{
    var url = environment.baseUrl + 'api/seed/registerUser/';
    return this.http.post<any>(url,userRequest)

  }
}
