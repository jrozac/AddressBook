import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ModelErrorDto, ContactDto } from '../../api/api.phone.client';
import { ItemActionStatus } from '../generics/item-action-base';

@Component({
  selector: 'app-contact-edit-form',
  templateUrl: './contact-edit-form.component.html',
})
export class ContactEditFormComponent {

  @Input()
  public item: ContactDto;

  @Input()
  public error: ModelErrorDto;

  @Input()
  public status: ItemActionStatus;

  @Output()
  public actionCallback = new EventEmitter();

  @Output()
  public clearNotificationsCallback = new EventEmitter<string>();

  public action(): void {
    this.actionCallback.emit();
  }

  public clearNotifications(name: string): void {
    this.clearNotificationsCallback.emit(name);
  }

}
