import { Vehicle} from './../../models/vehicle';
import { SaveVehicle} from './../../models/saveVehicle';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { IfObservable } from 'rxjs/observable/IfObservable';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes:any[]=[];
  models:any;
  vehicle:SaveVehicle={
    id:0,
    makeId:0,
    modelId:0,
    features:[],
    isRegistered:false,
    contact:{
      name:'',
      phone:'',
      email:''
    }
  };
  features:any[]=[];
  constructor(private vehicleService:VehicleService, 
    private toastyService:ToastyService,
    private route:ActivatedRoute,
    private router:Router) { 
      route.params.subscribe(p=>this.vehicle.id=+p['id']||0);
    }

  ngOnInit() {

    var sources=[
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if(this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));
    
    Observable.forkJoin(sources).subscribe(data=>{
      this.makes=data[0];
      this.features=data[1];

      if(this.vehicle.id){
        this.setVehicle(data[2]);
        this.poputlateModel();
      }
    },err=>{
      if(err.status==404)
        this.router.navigate(['/home']);
    });
  }

  private setVehicle(v:Vehicle){
    var featureId:number[]=[];
    this.vehicle.makeId=v.make.id;
    this.vehicle.modelId=v.model.id;
    this.vehicle.isRegistered=v.isRegistered;
    this.vehicle.contact=v.contact;
    v.features.forEach(feature=>{
      featureId.push(feature.id);
    });
    this.vehicle.features=featureId;
  }

  onMakeChange(){
    this.poputlateModel();
    delete this.vehicle.modelId;
  }

  private poputlateModel(){
    var selectedMake=this.makes.find(m=>m.id==this.vehicle.makeId);
    this.models=selectedMake? selectedMake.models:[];
  }
  
  onFeatureToggle(featureId:number,$event:any){
    if($event.target.checked)
      this.vehicle.features.push(featureId);
    else{
      var index=this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index,1);
    }
  }

  submit(){
    this.vehicle.id? this.vehicleService.updateVehicle(this.vehicle): this.vehicleService.createVehicle(this.vehicle);
    // if(this.vehicle.id)
    //   this.vehicleService.updateVehicle(this.vehicle).subscribe();
    // else{
    //   this.vehicleService.createVehicle(this.vehicle)
    //   .subscribe(x=>console.log(x));
    // }
    this.router.navigate(['/vehicles']);
  }

  // delete(){
  //   if(confirm("Are you sure to delete this?")){
  //     this.vehicleService.deleteVehicle(this.vehicle.id).subscribe(x=>{
  //       console.log(x);
  //       this.router.navigate(['/home']);
  //     });
  //   }
  // }
}
