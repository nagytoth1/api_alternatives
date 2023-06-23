package spring.dolgozo.apicontroller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import spring.dolgozo.model.Dolgozo;
import spring.dolgozo.repo.DolgozoRepository;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/dolgozo")
public class DolgozoController {
    @Autowired
    private DolgozoRepository repo;

    @GetMapping("/")
    @ResponseBody
    public ResponseEntity<List<Dolgozo>> getDolgozok(){
        try{
            List<Dolgozo> cars = repo.findAll();
            return new ResponseEntity<>(cars, HttpStatus.OK);
        }
        catch(Exception e){
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @GetMapping("/find")
    @ResponseBody
    public ResponseEntity<Dolgozo> getDolgozok(@RequestParam(name = "id") int id){
        Optional<Dolgozo> dolg = repo.findById(id);
        if(dolg.isEmpty())
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        return new ResponseEntity<>(dolg.get(), HttpStatus.OK);
    }

    @PostMapping("/create")
    @ResponseBody
    public ResponseEntity<Dolgozo> addDolgozo(@ModelAttribute Dolgozo dolgozo){
        try{
            return new ResponseEntity<>(repo.save(dolgozo), HttpStatus.OK);
        }
        catch(Exception e){
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PutMapping("/update")
    @ResponseBody
    public ResponseEntity<Dolgozo> updateDolgozo(@RequestParam("id") int id, @ModelAttribute Dolgozo dolg){
        try{
            Optional<Dolgozo> found = repo.findById(id);
            if(!found.isPresent())
                return new ResponseEntity<>(null, HttpStatus.NOT_FOUND);

            Dolgozo updatedDolg = found.get();
            updatedDolg.setNev(dolg.getNev());
            updatedDolg.setFoto(dolg.getFoto());
            updatedDolg.setReszleg_id(dolg.getReszleg_id());
            repo.save(updatedDolg);
            return new ResponseEntity<>(repo.save(updatedDolg), HttpStatus.OK);
        }
        catch(Exception e){
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @DeleteMapping("/delete")
    @ResponseBody
    public ResponseEntity<Dolgozo> deleteDolgozo(@RequestParam("id") int id){
        try{
            Optional<Dolgozo> found = repo.findById(id);
            if(found.isEmpty())
                return new ResponseEntity<>(HttpStatus.NOT_FOUND);
            Dolgozo dolgToRemove = found.get();
            repo.delete(dolgToRemove);
            return new ResponseEntity<>(dolgToRemove, HttpStatus.OK);
        }
        catch(Exception e){
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
}
