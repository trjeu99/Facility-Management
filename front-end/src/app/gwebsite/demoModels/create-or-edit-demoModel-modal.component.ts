import { AfterViewChecked, Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { DemoModelInput, DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditDemoModelModal',
    templateUrl: './create-or-edit-demoModel-modal.component.html'
})
export class CreateOrEditDemoModelModalComponent extends AppComponentBase implements AfterViewChecked {

    @ViewChild('demoModelNameInput') demoModelNameInput: ElementRef;
    @ViewChild('createOrEditModal') modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    demoModel: DemoModelInput = new DemoModelInput();
    constructor(
        injector: Injector,
        private _demoModelService: DemoModelServiceProxy
    ) {
        super(injector);
    }

    ngAfterViewChecked(): void {
        //Temporary fix for: https://github.com/valor-software/ngx-bootstrap/issues/1508
        $('tabset ul.nav').addClass('m-tabs-line');
        $('tabset ul.nav li a.nav-link').addClass('m-tabs__link');
    }

    show(demoModelId?: number): void {
        const self = this;
        self.active = true;

        self._demoModelService.getDemoModelForEdit(demoModelId).subscribe(result => {
            self.demoModel = result;

            self.modal.show();
        });
    }

    onShown(): void {
        $(this.demoModelNameInput.nativeElement).focus();
    }

    save(): void {
        const self = this;

        var input = new DemoModelInput();
        input = self.demoModel;

        this.saving = true;
        this._demoModelService.createOrEditDemoModel(input)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
