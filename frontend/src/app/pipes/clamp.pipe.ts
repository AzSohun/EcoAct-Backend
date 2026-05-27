// pipes/clamp.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'clamp', standalone: true })
export class ClampPipe implements PipeTransform {
    transform(value: number, min = 0, max = 100): number {
        return Math.min(max, Math.max(min, value));
    }
}