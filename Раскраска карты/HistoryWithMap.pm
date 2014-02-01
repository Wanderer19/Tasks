package HistoryWithMap;
	sub New{
		my $class = shift;
		my $self = {};
		$self->{events} = [];
		$self->{map} = undef;
		
		return bless $self, $class;
	}
	
	sub SaveCountry{
		my $self = shift;
		my @coordinates = @_;
		
		$self->{map}->SaveCountry(@coordinates);
		push @{$self->{events}}, \@coordinates;
	}
	
	sub DeleteCountry{
		my $self = shift;
		my @coordinates = @_;
		
		$self->{map}->DeleteCountry(@coordinates);
	}
	
	sub Clear{
		my $self = shift;
		
		@{$self->{events}} = ();
		$self->{map}->clear();
	}
	
	sub Cancel{
		my $self = shift;
		my @last_event = @{pop @{$self->{events}}};
	
		$self->{map}->DeleteCountry(@{$last_event});
	}
	
	sub GetMatrixMap{
		my $self = shift;
		
		return $self->{map}->GetMatrixMap();
	}
1;