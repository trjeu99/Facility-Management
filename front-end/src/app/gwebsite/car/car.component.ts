// import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Component, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
// import * as moment from 'moment';

@Component({
    templateUrl: './car.component.html',
    styleUrls: ['./car.component.less'],
    animations: [appModuleAnimation()],
})
export class CarComponent extends AppComponentBase {
    constructor(injector: Injector) {
        super(injector);
    }

    title = "Hiện thị trang thành công";

}
