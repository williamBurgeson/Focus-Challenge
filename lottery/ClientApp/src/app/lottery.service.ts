import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FinalResult } from './models/final-result';
import { PartialResult } from './models/partial-result';

@Injectable({
  providedIn: 'root'
})
export class LotteryService {

  constructor(private readonly _httpClient: HttpClient) { }

  getNextBall(partialResult: PartialResult) {
    return this._httpClient.post<PartialResult>('api/lottery/partial-result', partialResult);
  }

  getFinalResult(partialResult: PartialResult) {
    return this._httpClient.post<FinalResult>('api/lottery/final-result', partialResult);
  }
}
