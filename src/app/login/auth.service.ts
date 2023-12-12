import { Injectable } from '@angular/core';
import { LoginRequest } from './login-request';
import { environment } from 'src/environments/environment.development';
import { Observable, Subject, tap } from 'rxjs';
import { LoginResult } from './login-result';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  key = "comp584-token";
  private _authStatus = new Subject<boolean>();
  public authStatus = this._authStatus.asObservable();
  //authstatus is observable of whetehr we are logged in or not

 //passing that value throuhg constructor is dependency injection
 constructor(protected http: HttpClient) { }

 init(){
   console.log("printing",this.isAuthenticated());
   if(this.isAuthenticated()){
     this.setAuthStatus(true);
   }
 }

 getToken(): string | null{

   return localStorage.getItem(this.key);

 }

 isAuthenticated() : boolean{

   return this.getToken() != null;
 }
// by setting the authstatus as observable, we are publishing the subject of that value so that other areas of application can subscribe to
 setAuthStatus(isAuthenticated : boolean){
   this._authStatus.next(isAuthenticated);
 }
 //below login returns an observable of loginresult

 
 login(loginItem: LoginRequest) : Observable<LoginResult>{
   var url =  environment.baseUrl + 'api/Admin';
   return this.http.post<LoginResult>(url,loginItem)
   .pipe(tap((loginResult: LoginResult) => {
     if (loginResult.success && loginResult.token){
       localStorage.setItem(this.key,loginResult.token)
       this.setAuthStatus(true);
     }
   }));

 }

 logout(){
   localStorage.removeItem(this.key);
   this.setAuthStatus(false);
   
 }
}
