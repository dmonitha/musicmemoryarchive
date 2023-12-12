import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../login/auth.service';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy{

  isLoggedIn: boolean = false;
  private destroySubject = new Subject();
 
  constructor(private authService: AuthService, private router: Router){
   // we are subscribing to auth status and whenever that value changes we will be notified
   this.isLoggedIn = this.authService.isAuthenticated();
   this.authService.authStatus.pipe(takeUntil(this.destroySubject))
   .subscribe(result => {
     this.isLoggedIn = result;
   })
  }
   ngOnDestroy(): void {
     this.destroySubject.next(true);
     this.destroySubject.complete();
   }
 
  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
  }
 
  onLogout() {
   this.authService.logout();
   this.router.navigate(['/']);   
  }
 }
