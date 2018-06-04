import { PhotoService } from './../../services/photo.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle:any;
  vehicleId:any;
  photos:any[]=[];
  @ViewChild('fileInput')fileInput:ElementRef | undefined;

  constructor(private route:ActivatedRoute,
              private vehicleService:VehicleService,
              private photoService:PhotoService,
              private router:Router) { 
      this.route.params.subscribe(param=>{
        this.vehicleId=+param['id'];
      if(isNaN(this.vehicleId)|| this.vehicleId<=0){
        router.navigate(['/vehicles']);
        return;
      }
      });
    }

  ngOnInit() {
    this.photoService.getPhotos(this.vehicleId).subscribe(p=>{
      this.photos=p;
      console.log(this.photos);      
    });
    this.vehicleService.getVehicle(this.vehicleId).subscribe(vehicle=>{
      this.vehicle=vehicle;
    });
  }
  
  editVehicle(){
      this.router.navigate(['/vehicles/edit/'+this.vehicleId]);
  }

  deleteVehicle(){
    if(confirm("Are you sure to delete this?")){
      this.vehicleService.deleteVehicle(this.vehicleId).subscribe(x=>{
        console.log(x);
        this.router.navigate(['/vehicles']);
      });
    }
  }

  viewAllVehicle(){
    this.router.navigate(['/vehicles']);
    return;
  }

  uploadPhoto(){
    var realElement:any;
    var nativeElement:HTMLInputElement= this.fileInput? this.fileInput.nativeElement:undefined;
    if(nativeElement)
      realElement=nativeElement;
    this.photoService.uploadPhoto(this.vehicleId,realElement.files[0])
    .subscribe(photo=>this.photos.push(photo));
  }
  
}
