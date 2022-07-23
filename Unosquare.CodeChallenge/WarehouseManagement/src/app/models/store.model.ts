import { IStore } from "../interfaces/istore";

export class Store implements IStore {
    public Id: number ;
    public storeName: string;
    public address: string;
    public city: string;
    public products:[]=[];

  constructor(id:number,storeName:string,address:string, city:string) {
    this.Id = id;
    this.storeName = storeName;
    this.address = address;
    this.city = city;

  }

  setId(id: number) {
    this.Id = id;
  }

}
