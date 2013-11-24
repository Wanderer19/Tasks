package HistoryWithGeometry;
	use Class::Struct;
	use libs::Template;
	use libs::Menu;
	use libs::Geometry;
	use resources::Settings;
	
	struct HistoryWithGeometry =>{
		events => '@',
		geometry => '$'
	};
	
	sub save_template_word{
		my $self = shift;
		my @points = @_;
		
		if ($self->geometry->save_template_word(@points)){
			push @{$self->events}, ["append", \@points];
			return 1;
		}
		
		return 0;
	}
	
	sub delete_word{
		my $self = shift;
		my @points = @_;
		
		my @endpoints = $self->geometry->delete_word(@points);
		if ($endpoints[0]){
			push @{$self->events} , ["remove", @endpoints];
			return 1;
		}
		
		return 0;
	}
	
	sub clear{
		my $self = shift;
		
		@{$self->events} = ();
		$self->geometry->clear();
	}
	
	sub undo_fast_event{
		my $self = shift;
		my @last_event = @{pop @{$self->events}};
	
		if ($last_event[0] eq "remove"){
			$self->geometry->save_template_word(@{$last_event[1]});
		}
		elsif($last_event[0] eq "append"){
			$self->geometry->delete_word(@{$last_event[1]});
		}
	}
	
	sub get_matrix_geometry{
		my $self = shift;
		
		return $self->geometry->get_matrix_geometry();
	}
	
	sub is_geometry_undefined{
		my $self = shift;
		
		return $self->geometry->is_geometry_undefined();
	}
	
1;