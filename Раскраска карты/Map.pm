package Map;
	sub New{
		my $class = shift;
		
		my $self = {};
		$self->{countries} = [];
		
		return bless $self, $class;
	}
	
	sub SaveCountry{
		my $self = shift;
		my @coordinates = @_;
		
		push @{$self->{countries}}, Country->New(@coordinates);
	}
	
	sub DeleteCountry{
		my $self = shift;
		
		pop @{$self->{countries}};

		for (my $i = 0; $i < scalar @{$self->{countries}} - 1; ++$i){
			my $country = $self->{countries}->[$i];
			for ($country->GetLines()){
				my $flag = 0;
			
				for(my $j = $i + 1; $j < scalar @{$self->{countries}}; ++$j){
					if ($country->Overlap($_, $self->{countries}->[$j])){

						$country->{intersects}->{$i} = 1;

					}
				}
			}
		}
	}
	
	sub GetMatrixMap{
		my $self = shift;
		$self->GetIntersections();
		
		my @countries = @{$self->{countries}};
		my @matrix;
		my $index = 0;
		for (@countries){
			for my $i (0 .. $#countries){

				$matrix[$index][$i] = 0 unless ($matrix[$index][$i]);

				

				if ($_->{intersects}->{$i} == 1){
					$matrix[$index][$i] = 1;
					$matrix[$i][$index] = 1;
				}
			}
			$index ++;
		}
	
		return \@matrix;
	}

	
	sub GetCoordinates{
		my $self = shift;
		my $index = shift;
		
		return $self->{countries}->[$index]->GetCoordinates();
	}


1;
