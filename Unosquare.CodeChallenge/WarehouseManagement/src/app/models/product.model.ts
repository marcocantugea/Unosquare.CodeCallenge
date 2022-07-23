import { ICompany } from "../interfaces/ICompany";
import { IProduct } from "../interfaces/iproduct";
import { IStore } from "../interfaces/istore";

export class Product implements IProduct {
    public id: number;
    public name: string;
    public description: string;
    public ageRestriction: number;
    public company: ICompany;
    public price: number;
    public imageIurl: string;
    public companyId: number;
    public storeid: number;
    public store: IStore;
    public warehouseInfo;

  constructor(
    id: number,
    name: string,
    descripcion: string,
    ageRestriction: number,
    company: ICompany,
    price: number,
    imageUrl: string,
    companyId: number,
    storeid: number,
    store: IStore,
    warehouseInfo:[]=[]
  ) {

      this.id=id;
      this.name = name;
      this.description = descripcion;
      this.ageRestriction = ageRestriction;
      this.company = company;
      this.price = price;
      this.imageIurl = imageUrl;
      this.companyId = companyId;
      this.storeid = storeid;
      this.store = store;
      this.warehouseInfo = warehouseInfo;

    }
}
