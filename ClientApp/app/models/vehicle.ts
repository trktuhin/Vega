export interface KeyValuePair{
    id:number;
    name:string;
}

export interface Contact{
    name:string;
    phone:string;
    email:string;
}

export interface Vehicle{
    id:number;
    make:KeyValuePair;
    model:KeyValuePair;
    features:KeyValuePair[];    
    isRegistered:boolean;
    contact:Contact;
    lastUpdate: string;
}
