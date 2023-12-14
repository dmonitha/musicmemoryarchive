import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Custom } from './custom';
import { environment } from 'src/environments/environment.development';
import { Album } from '../albums/album';
import { CustomService } from './custom.service';

@Component({
  selector: 'app-custom',
  templateUrl: './custom.component.html',
  styleUrls: ['./custom.component.css']
})
export class CustomComponent {
  public albumData : Album[] = [];
  public customData : Custom[] =[];
  constructor(http: HttpClient,protected customService : CustomService) {
    http.get<Album[]>(environment.baseUrl + 'api/album').subscribe
    ({
      next : result => {
      this.albumData = result;
    }, 
    error:error => {console.error(error)}
   } );
  }

  onSelect(albumId: number){
  
    this.customService.fetchData(albumId).subscribe
    ({
      next: result => {
             this.customData = result;
      },
      error: error => {console.log(error);}
    })
    
  }
}












