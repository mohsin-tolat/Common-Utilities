import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EncryptionService } from '../encryption-utility/encryption.service';
import { AlertComponent } from './alert/alert.component';
import { AlertService } from './alert/alert.service';

@NgModule({
  imports: [CommonModule, HttpClientModule],
  declarations: [AlertComponent],
  exports: [
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AlertComponent,
  ],
  providers: [AlertService, EncryptionService],
})
export class SharedModule {}
