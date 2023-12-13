import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AlbumsComponent } from './albums/albums.component';
import { LoginComponent } from './login/login.component';
import { SongsComponent } from './songs/songs.component';
import { CustomComponent } from './custom/custom.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path:'',component:HomeComponent, pathMatch:'full'},
  {path:'albums',component:AlbumsComponent},
  {path: 'login', component: LoginComponent},
  {path: 'song', component: SongsComponent},
  {path: 'custom', component: CustomComponent},
  {path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
