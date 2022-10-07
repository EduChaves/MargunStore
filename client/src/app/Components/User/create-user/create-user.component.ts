import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Address } from 'src/app/Models/Address';
import { Client } from 'src/app/Models/Client';
import { User } from 'src/app/Models/User';
import { AddressService } from 'src/app/Services/address.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  form: any;
  errors: string[] = [];
  address: Address = {};

  constructor(
    private userService: UserService,
    private addressService: AddressService,
    private snackBar: MatSnackBar,
    public  dialogReference: MatDialogRef<CreateUserComponent> 
    ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(40)]),
      email: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(30)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8), Validators.maxLength(20)]),
      confirmPassword: new FormControl(null, [Validators.required, Validators.minLength(8), Validators.maxLength(20)]),
      phoneNumber: new FormControl(null, [Validators.required]),
      street: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
      number: new FormControl(null, [Validators.required]),
      district: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
      city: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
      state: new FormControl(null, [Validators.required]),
      complement: new FormControl(null),
      cep: new FormControl(null, [Validators.required]),
    })
  }

  get Controls() {
    return this.form.controls
  }

  SubmitForm() {
    debugger
    const data = this.form.value;

    const address: Address = {
      street: data.street,
      number: data.number,
      district: data.district,
      city: data.city,
      state: data.state,
      complement: data.complement,
      cep: data.cep,
    }
    const client: Client = {
      name: data.name,
      addresses: [],
    };
    client.addresses.push(address);
    const user : User = {
      email: data.email,
      password: data.password,
      confirmPassword: data.confirmPassword,
      client: client,
    }
    this.userService.CreateUser(user).subscribe(result => {
      this.snackBar.open("Usuário cadastrado com sucesso", "", {
        duration: 2000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      })
      //localStorage.setItem('')
      console.log(result);
      this.dialogReference.close();
    }, exception => {
        this.RecoverExceptions(exception);
        console.log(this.errors);
    });
  }

  RecoverExceptions(exception: any){
    if(exception.error.errors.hasOwnProperty('Email')) {
       var error = exception.error.errors.Email as string[];
       error.forEach(value => this.errors.push(value))
    }

    if(exception.error.errors.hasOwnProperty('Password')){
      var error = exception.error.errors.ConfirmPassword as string[];
      error.forEach(value => this.errors.push(value))
    }

   if(exception.error.errors.hasOwnProperty('ConfirmPassword')){
      var error = exception.error.errors.ConfirmPassword as string[];
      error.forEach(value => this.errors.push(value))
    }
  }

  GetCep() {
    if(this.Controls.cep.value != null) {
      this.addressService.GetCep(this.form.controls.cep.value).subscribe(result => {
        this.address = {
          street: result.street,
          district: result.district,
          city: result.city,
          state: result.state,
        }
      }, err => console.log(err))
    }
  }
}

