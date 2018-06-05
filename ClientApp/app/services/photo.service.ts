import { Http } from '@angular/http';
import { Injectable, Class } from '@angular/core';

@Injectable()
export class PhotoService{
    constructor(private http:Http){}
    uploadPhoto(vehicleId:number,photo:any){
        var formData= new FormData();
        formData.append("fileStream",photo);
        // console.log(formData);
        return this.http.post(`/api/vehicles/${vehicleId}/photos`,formData)
        .map(res=>res.json());
    }

    getPhotos(vId:number){
        return this.http.get("/api/vehicles/"+vId+"/photos").map(res=>res.json());
    }
}