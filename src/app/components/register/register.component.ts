import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { AlertService } from '../../services/alert.service';
import { UserService } from '../../services/users.service';
import { AddressService } from '../../services/address.service';
import { FilesService } from '../../services/files.service';
import { User, Company, Address } from '../../shared/models';

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html',
    styleUrls: ['../../shared/global.css'],
    providers: [ UserService, AlertService, FilesService, AddressService ]
})

export class RegisterComponent {
    public user: User = new User();
    public addr: Address  = new Address();
    public loading = false;
    progress = 0;
    files: any;
    regis: IRegistration;
    regUserForm: FormGroup;
    regCompanyForm: FormGroup;
    regAddressForm: FormGroup;
    contactList: string;
    contactType: { value: string, name: string }[];
    constructor(
        private router: Router,
        private userService: UserService,
        private fileService: FilesService,
        private alertService: AlertService,
        private addressService: AddressService,
        private fb: FormBuilder) {
            this.regis = new IRegistration();
            this.contactList = '';
            this.contactType = [
                { 'value': 'email', 'name': 'Эл. почта'},
                { 'value': 'tel', 'name': 'Телефон'},
                { 'value': 'tg', 'name': 'Telegram'},
                { 'value': 'skype', 'name': 'Skype'},
                { 'value': 'viber', 'name': 'Viber'}
            ];
            this.regUserForm = fb.group({
                'lastName': ['', [Validators.required]],
                'firstName': ['', [Validators.required]],
                'secondName': ['', [Validators.pattern]],
                'telephone': ['', [Validators.required]],
                'email': ['', [Validators.required]],
                'password': ['', [Validators.required]],
                'repeat': ['', [Validators.required, matchOtherValidator('password')]]
            });
            this.regCompanyForm = fb.group({
                'name': ['', [Validators.required]],
                'shortName': ['', [Validators.required]],
                'contacts': ['', [Validators.required]],
                'about': ['', [Validators.pattern]],
                'pan': ['', [Validators.required]],
                'addressId': ['', [Validators.nullValidator]]
            });
            this.regAddressForm = fb.group({
                'street': ['', [Validators.required]],
                'number': ['', [Validators.required]],
                'flat': ['', [Validators.required]]
            });
        }
    addContact(contact: string, option: string) {
        switch (option) {
            case 'tg': {
                this.contactList += '<p><i class="fa fa-telegram " aria-hidden="true"></i><a title="Telegram" href="tg://resolve?domain=' +
                    contact + '">' + contact + '</a></p>';
                this.regCompanyForm.value.contacts = this.contactList;
                break;
            }
            case 'email': {
                this.contactList += '<p><i class="fa fa-envelope" aria-hidden="true"></i><a title="E-Mail" href="mailto:' +
                    contact + '">' + contact + '</p>';
                this.regCompanyForm.value.contacts = this.contactList;
                break;
            }
            case 'tel': {
                this.contactList += '<p><i class="fa fa-phone " aria-hidden="true"></i><a title="Позвонить" href="tel:' +
                    contact + '">' + contact + '</p>';
                this.regCompanyForm.value.contacts = this.contactList;
                break;
            }
            case 'skype': {
                this.contactList += '<p><i class="fa fa-skype" aria-hidden="true"></i><a title="Skype" href="skype:' +
                    contact + '?chat">' + contact + '</p>';
                this.regCompanyForm.value.contacts = this.contactList;
                break;
            }
            case 'viber': {
                this.contactList += '<p><i class="fa fa-whatsapp" aria-hidden="true"></i><a title="Viber" href="viber://add?number=' +
                    contact + '?chat">' + contact + '</p>';
                this.regCompanyForm.value.contacts = this.contactList;
                break;
            }
            default: {
                console.log('Invalid contact option: ' + option);
                break;
            }
        }
    }
    addImage(event: any) {
        const target =  event.target || event.srcElement;
        this.files = target.files;
        console.log(this.files);
    }

    register() {
        this.loading = true;
        this.addr.street = this.regAddressForm.value.street;
        this.addr.number = this.regAddressForm.value.number;
        this.addr.flat = this.regAddressForm.value.flat;
        this.regis.company = new Company();
        this.regis.company.name = this.regCompanyForm.value.name;
        this.regis.company.shortName = this.regCompanyForm.value.shortName;
        this.regis.company.about = this.regCompanyForm.value.about;
        this.regis.company.pan = this.regCompanyForm.value.pan;
        this.regis.company.contacts = this.regCompanyForm.value.contacts;
        this.addressService.create(this.addr).subscribe(data => {
            this.regis.company.addressId = data.json().idAddresses;
        });
        if (this.files) {
            let files : FileList = this.files;
            const formData = new FormData();
            for (let i = 0; i < files.length; i++) {
                formData.append('file', files[i]);
            }
            this.fileService.uploadImage(formData).subscribe(data => {
                console.log(data);
                this.regis.company.imagesId = data.json().idImages ;
            });
        } else {
            this.regis.company.imagesId = 1;
        }
        this.progress = 30;
        this.regis.user = new User();
        this.regis.user.email = this.regUserForm.value.email;
        this.regis.user.firstName = this.regUserForm.value.firstName;
        this.regis.user.lastName = this.regUserForm.value.lastName;
        this.regis.user.secondName = this.regUserForm.value.secondName;
        this.regis.user.pass = this.regUserForm.value.password;
        this.regis.user.telephone = this.regUserForm.value.telephone;
        this.progress = 60;

        this.userService.register(this.regis).subscribe(data => {
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/login']);
            this.progress = 100;
        },
        error => {
            console.log(error._body);
            this.loading = false;
            this.progress = 0;
        });
    }

}
export class IRegistration {
    user: User;
    company: Company;
}
export function matchOtherValidator (otherControlName: string) {

    let thisControl: FormControl;
    let otherControl: FormControl;

    return function matchOtherValidate (control: FormControl) {

      if (!control.parent) {
        return null;
      }
      // Initializing the validator.
      if (!thisControl) {
        thisControl = control;
        otherControl = control.parent.get(otherControlName) as FormControl;
        if (!otherControl) {
          throw new Error('matchOtherValidator(): other control is not found in parent group');
        }
        otherControl.valueChanges.subscribe(() => {
          thisControl.updateValueAndValidity();
        });
      }
      if (!otherControl) {
        return null;
      }
      if (otherControl.value !== thisControl.value) {
        return {
          matchOther: true
        };
      }
      return null;
    }
}
