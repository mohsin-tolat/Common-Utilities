import { Component, OnInit } from '@angular/core';
import { AlertService } from '../shared/alert/alert.service';
import { EncryptionService } from './encryption.service';

@Component({
  selector: 'app-encryption-utility',
  templateUrl: './encryption-utility.component.html',
  styleUrls: ['./encryption-utility.component.scss'],
})
export class EncryptionUtilityComponent implements OnInit {
  plainText = '';
  encryptedText = '';
  constructor(
    private alertService: AlertService,
    private encryptionService: EncryptionService
  ) {}

  ngOnInit() {}

  encryptText() {
    this.encryptionService.GetEncryptedText(this.plainText).subscribe(
      response => {
        if (response.statusCode === 200) {
          this.encryptedText = response.result;
        } else {
          this.alertService.error('Error occured while Encrypting Text');
        }
      },
      err => {
        this.alertService.error('Error occured while Encrypting Text');
      }
    );
  }

  decryptText() {
    this.encryptionService.GetDecryptedText(this.encryptedText).subscribe(
      response => {
        if (response.statusCode === 200) {
          this.plainText = response.result;
        } else {
          this.alertService.error('Error occured while Encrypting Text');
        }
      },
      err => {
        this.alertService.error('Error occured while Decrypting Text');
      }
    );
  }
}
