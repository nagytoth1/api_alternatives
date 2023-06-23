package spring.dolgozo.repo;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import spring.dolgozo.model.Dolgozo;

@Repository
public interface DolgozoRepository extends JpaRepository<Dolgozo, Integer> {
}
