import { AbstractControl, ValidatorFn } from '@angular/forms';

export class ProductFormValidators {


  constructor() {  }

  static validateNotEmptyString(control: AbstractControl){
    const regexp = /(.*[a-z]){3}/i;
    const valid = regexp.test(control.value);
    return valid ? null : { invalidBranch: true };
  }

  static validateCurrency(control: AbstractControl) {
    const regexp = /^\d+(?:\.\d{2})?$/;
    const valid = regexp.test(control.value);
    return valid ? null : { invalidBranch: true };
  }

  static validatePriceZero(control: AbstractControl) {
    return (control.value==0) ? { invalidBranch: true } : null;
  }

  static validateSelector(control: AbstractControl) {
    return (control.value != -1) ? null : { invalidBranch: true };
  }

  static validateNumbersOnly(control: AbstractControl) {
    
    const regexp =/^[0-9]+$/;
    const valid = regexp.test(control.value);
    return valid ? null : { invalidBranch: true };
    
  }

  static validateBettwenNumbers1and100(control: AbstractControl) {
    return (Number.parseInt(control.value) >= 1 && Number.parseInt( control.value) <= 100) ?null : { invalidBranch: true };
  }

  static validateHttpLink(control: AbstractControl) {
    
    const regexp = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/;
    const valid = regexp.test(control.value);
    return (valid || control.value=="") ? null : { invalidBranch: true };
  }
}
