import { Router } from '@angular/router';
import { Vehicle, KeyValuePair } from './../../models/vehicle';

import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles:Vehicle[]=[];
  allVehicles:Vehicle[]=[];
  makes:KeyValuePair[]=[];
  filter:any={};

  constructor(private vehicleService:VehicleService,private router:Router) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes=>{
      this.makes=makes;
    })
    this.vehicleService.getVehicles().subscribe(v=>{
      this.vehicles=this.allVehicles=v;
    });
  }

  viewVehicle(id:number){
    this.router.navigate(['/vehicles/'+id]);
  }

  addVehicle(){
    this.router.navigate(['/vehicles/new']);
  }

  onFilterChange(){
    // console.log("mehtod called");
    var vehicles=this.allVehicles;
    if(this.filter.makeId)
      vehicles=vehicles.filter(v=>v.make.id==this.filter.makeId);
    this.vehicles=vehicles;
  }

  onReset(){
    this.vehicles=this.allVehicles;
    this.filter={};
  }

}
