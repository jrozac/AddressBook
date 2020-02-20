import { Component, Input, ViewChild, EventEmitter, Output } from '@angular/core';
import * as $ from 'jquery';
import "bootstrap";

@Component({
  selector: 'app-modal-window',
  templateUrl: './modal-window.component.html',
})
export class ModalWindowComponent {

  @ViewChild('modal', { static: false }) modal: any;

  @Input()
  public header: string;

  @Input()
  public modalId: string;
  
  @Input()
  public message: string;

  @Input()
  public actionLabel: string;

  @Output()
  public actionCallback = new EventEmitter();

  public action(): void {
    this.actionCallback.emit();
    this.close();
  }

  public open(): void {
    $(this.modal.nativeElement).modal('show');
  }

  public close(): void {
    $(this.modal.nativeElement).modal('hide');
  }

}
