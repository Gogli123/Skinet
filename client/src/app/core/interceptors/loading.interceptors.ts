import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, delay, finalize } from "rxjs";
import { BusyService } from "../services/busy.service";
import { Injectable } from "@angular/core";

@Injectable()
export class LoadingInterceptors implements HttpInterceptor {
    constructor(private busyService: BusyService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!req.url.includes('emailexists')){
            this.busyService.busy();
        }
        return next.handle(req).pipe(
            delay(500),
            finalize(() => {
                this.busyService.idle();
            })
        );
    }
}