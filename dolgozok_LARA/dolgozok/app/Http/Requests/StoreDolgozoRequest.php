<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreDolgozoRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array|string>
     */
    public function rules(): array
    {
        return [
            'nev' => 'required|string|max:50|min:4|alpha_num',
            'foto' => 'required|string|max:50|min:3|alpha_num',
            'reszleg_id' => 'required|integer|max:50|min:4|alpha_num|exists:reszleg,id',
        ];
    }
}
