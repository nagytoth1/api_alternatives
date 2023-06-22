<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('dolgozo', function (Blueprint $table) {
            $table->id();
            $table->string('nev', 50);
            $table->foreignIdFor(Reszleg::class)->unsigned()->nullable()->onDelete('set null');
            $table->string('foto_nev', 50);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('dolgozo');
    }
};
