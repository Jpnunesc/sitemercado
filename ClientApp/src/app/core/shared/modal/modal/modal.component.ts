import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() opem: boolean = false;
  @Input() id: any;
  @Output() Itemselecionado = new EventEmitter();
  @Output() cancelar = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  fechar() {
    this.cancelar.emit(false);
  }
  excluir() {
      this.Itemselecionado.emit(this.id);
  }
}
