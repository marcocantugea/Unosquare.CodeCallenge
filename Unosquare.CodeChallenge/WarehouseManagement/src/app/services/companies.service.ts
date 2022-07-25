import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Company } from '../models/company.model';
import { ICompany } from '../interfaces/ICompany';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompaniesService {

  private host: string = (environment.APIhost) ? environment.APIhost : 'https://localhost:7032/';
  private apiResouce: string  = 'api/company';
  private apiResoucePlural:string = 'api/companies';

  private listOfCompanies: Observable<ICompany> | null = null;
  public listOfCompaniesBehavior = new BehaviorSubject<ICompany[]>([]);
  listOfCOmpaniesBehavior$ = this.listOfCompanies;

  constructor(
    private http: HttpClient
  ) { }

  getAllCompanies(): Observable<ICompany[]> {
    return this.http.get<ICompany[]>(this.host + this.apiResoucePlural);
  }

  getCompany(id: string) : Observable<ICompany> {
    return this.http.get<ICompany>(this.host + this.apiResouce + "/" + id);
  }

  getCompanyByName(name: string): Observable<ICompany> {
    return this.http.get<ICompany>(this.host + this.apiResouce + "/search?name=" + name);
  }

  addCompany(name: string): Observable<any>  {
    let item = {
      Name:name 
    }
    const headers = { 'Content-type': 'application/json' };
    return this.http.post(this.host + this.apiResouce, JSON.stringify(item), { headers });
  }

  deleteCompany(idCompany: string): Observable<any> {
    let item = {
      Id:idCompany
    }
    return this.http.delete(this.host + this.apiResouce+"/"+idCompany)
  }

  updateCompanyInfo(company: Company) {
    return this.http.put(this.host + this.apiResouce, company);
  }
}
