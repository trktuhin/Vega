import { Contact } from "./vehicle";

export interface SaveVehicle{
    id:number;
    makeId:number;
    modelId:number;
    features:number[];    
    isRegistered:boolean;
    contact:Contact;
}