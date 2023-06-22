<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class UpdateDolgozoRequest extends FormRequest
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
            'foto' => 'required|string|max:50|min:3|regex:/^[a-z0-9_.-]*$/',
            'reszleg_id' => 'required|integer|max:255|min:0|exists:reszleg,id',
        ];
    }
}
