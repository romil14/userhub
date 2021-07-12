import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-error-modal',
  templateUrl: './error-modal.component.html',
  styleUrls: ['./error-modal.component.css', '../modal-shared.component.css']
})
export class ErrorModalComponent implements OnInit {
  @Input() public modalHeaderText: string | undefined;
  @Input() public modalBodyText: string | undefined;
  @Input() public okButtonText: string | undefined;
  constructor() { }

  ngOnInit(): void {
  }

}
