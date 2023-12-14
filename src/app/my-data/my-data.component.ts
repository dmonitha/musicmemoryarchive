import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, FormGroup, FormControl, Validators } from '@angular/forms';
import { Token } from '@angular/compiler';
import { Router } from '@angular/router';
import { MydataService } from './mydata.service';
import { Album } from '../albums/album';
import { Song } from '../songs/song';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-my-data',
  templateUrl: './my-data.component.html',
  styleUrls: ['./my-data.component.css']
})
export class MyDataComponent {
  public albumData : Album[] = [];
  selectedAlbumId : number  | null =null; 
  form!: UntypedFormGroup;

  constructor(http: HttpClient,protected myDataService: MydataService,private router: Router){
    http.get<Album[]>(environment.baseUrl + 'api/album').subscribe
    ({
      next : result => {
      this.albumData = result;
    }, 
    error:error => {console.error(error)}
   } );
  }

  onRadioChange(albumId: number): void {
    this.selectedAlbumId = albumId;
  }

ngOnInit(): void {
  this.form = new FormGroup({
    songName: new FormControl("" , Validators.required),
    duration: new FormControl("" , Validators.required),
    rating: new FormControl("" , Validators.required),
    featuringArtist: new FormControl(null,Validators.nullValidator)
  })
}

onSubmit() {
  let songData : Song = {
    songName: this.form.controls['songName'].value,
    duration: this.form.controls['duration'].value,
    rating: this.form.controls['rating'].value,
    featuringArtist: this.form.controls['featuringArtist'].value,
    albumId : this.selectedAlbumId
  } 


this.myDataService.onCheckMethod(songData).subscribe 
  ({
  next: result => {
         console.log("well result is - ",result);
  },
  error: error => {console.log(error);}
})
this.form.reset();
this.router.navigate(['/song']);
}
}
