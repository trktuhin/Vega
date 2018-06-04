import { SaveVehicle } from './../models/saveVehicle';
import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http:Http) { }

  getMakes(){
    return this.http.get('/api/makes').map(res=>res.json());
  }

  getFeatures(){
    return this.http.get('/api/features').map(res=>res.json());
  }

  getVehicles(){
    return this.http.get('/api/vehicles').map(res=>res.json());
  }

  createVehicle(vehicle:any){
    return this.http.post('/api/vehicles',vehicle).map(res=>res.json());
  }

  getVehicle(id:number){
    return this.http.get('/api/vehicles/'+id).map(res=>res.json());
  }

  updateVehicle(vehicle:SaveVehicle){
    return this.http.put('/api/vehicles/'+vehicle.id,vehicle).map(res=>res.json());
  }

  deleteVehicle(id:number){
    return this.http.delete('/api/vehicles/'+id).map(res=>res.json());
  }
}
