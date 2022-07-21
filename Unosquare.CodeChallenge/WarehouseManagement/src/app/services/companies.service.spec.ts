import { HttpClientModule } from '@angular/common/http';
import { assertPlatform } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { Company } from '../models/company.model';

import { CompaniesService } from './companies.service';

describe('CompaniesService', () => {
  let service: CompaniesService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(CompaniesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('get observable for the companies list', () => {
    expect(service.getAllCompanies()).toBeInstanceOf(Observable);
  });

  it('get the list of companies', () => {
    let companies: Company[]=[];
    const companiesList$= service.getAllCompanies().subscribe(response => {
      response.forEach(item => {
        companies.push(new Company(item.Id, item.Name));
      });
    })

    companiesList$.unsubscribe();
    expect(1).toBeGreaterThan(companies.length);

  })

  it('get a company info', (done: DoneFn) => {
    const company: Company= new Company(0,'');
    const companyObs$=service.getCompany('MQ==').subscribe(
      response => {
        company.setId(response.Id);
        company.setName(response.Name);
        
        expect(1).toEqual(company.Id);
        expect('Mattel').toEqual(company.Name);
        done();
      }
    );

    //companyObs$.unsubscribe();
  });

  it('get a company by name', (done: DoneFn) => {
    const company: Company = new Company(0, '');
    service.getCompanyByName('Mattel').subscribe(
      response => {
        company.setId(response.Id);
        company.setName(response.Name);

        expect(1).toEqual(company.Id);
        expect('Mattel').toEqual(company.Name);
        done();
      }
    );
  });

  it('crear a company', (done: DoneFn) => {
    let company = new Company(0,'test company');
    service.addCompany(company.Name).subscribe(
      next => {
        expect(true).toBeTrue();
        done();
      },
      error => {
        expect(false).toBeTrue();
        done();
      }
    );
  });

  it('delete company', (done: DoneFn) => {
    
    service.addCompany('test company').subscribe(
      response => {
        const company: Company = new Company(0, 'test company');
        service.getCompanyByName(company.getName()).subscribe(
          next => {
            company.setId(next.Id);
            company.setName(next.Name);

            let idTodelete: string = btoa(company.Id.toString());

            service.deleteCompany(idTodelete).subscribe(
              next => {
                expect(true).toBeTrue();
              },
              error => {
                expect(false).toBeTrue();
              }
            )

            expect(company.getId()).toBeGreaterThan(1);
            done();
          }
        );
      },
      error => {
        expect(false).toBeTrue();
        done();
      }
    );
  });

  it('update company info', (done: DoneFn) => {
    const companyToUpdate = new Company(1, 'Mattel Inc.');
    const updateInfo$ = service.updateCompanyInfo(companyToUpdate).subscribe(
      next => {
        companyToUpdate.setName('Mattel');
        service.updateCompanyInfo(companyToUpdate).subscribe((next) => {
          expect(true).toBeTrue();
        });
        expect(true).toBeTrue();
        done();
      },
      (error) => {
        console.log(error);
        expect(false).toBeTrue();
        done();
      }
    );
  });

});
