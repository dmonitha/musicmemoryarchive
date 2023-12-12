import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AlbumsComponent } from './albums/albums.component';
import { LoginComponent } from './login/login.component';
import { SongsComponent } from './songs/songs.component';

const routes: Routes = [
  {path:'',component:HomeComponent, pathMatch:'full'},
  {path:'albums',component:AlbumsComponent},
  {path: 'login', component: LoginComponent},
  {path: 'song', component: SongsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
