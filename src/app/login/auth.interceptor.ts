import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService, private router : Router) {}


  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let token = this.authService.getToken();
    console.log("in here 1");

    if(token){
      ///cloning the request, adding token and sending that
      request = request.clone({
        setHeaders : {
          Authorization: `Bearer ${token}`
        }
      }
      );
    }

    return next.handle(request).pipe(
      catchError((error) => {
        //only catch 401
        
        if(error instanceof HttpErrorResponse && error.status === 401){
          console.log("in here");
        this.authService.logout();
        this.router.navigate(["login"])
        }
        return throwError(() => error);
      })
    );
  }
}
