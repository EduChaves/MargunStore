import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/user.service';
import { CreateUserComponent } from '../create-user/create-user.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any;
  user!: User;
  errors: string[] = [];

  constructor(
    private userService: UserService,
    private dialog: MatDialog
    ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      userName: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(20)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8), Validators.maxLength(20)])
    });
  }

  OpenDialog() {
    var result = this.dialog.open(CreateUserComponent, {

    });
  }

  SubmitForm(){
    const request = this.form.value as User;

    this.userService.Login(request).subscribe(result => {
      //TODO -> salvar no local storage as informações vindas deste request
    });
  }
}
