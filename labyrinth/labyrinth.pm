package labyrinth;
@ISA = ("input", "output");
use Tk;

sub new{
	my $Class = shift;
	my ($Labyrinth, $Enter1, $Enter2, $Exit1, $Exit2 , $Bombs) = @_;
	
	my $Self = {labyrinth=>$Labyrinth,enter1=>$Enter1, enter2=>$Enter2, exit1=>$Exit1, exit2=>$Exit2, bombs=>$Bombs};
	return bless $Self,$Class;
}

sub GetThePath{
	my $Labyrinth = shift;
	my ($Enter1, $Enter2, $Exit1, $Exit2, $Bombs) = ($Labyrinth->{enter1}, $Labyrinth->{enter2}, $Labyrinth->{exit1}, $Labyrinth->{exit2}, $Labyrinth->{bombs});
	
	my $Path = $Labyrinth->FindThePath();
	my (@Path, $Entry);
	for  (keys (%$Path)){
		$Entry = $_ if (substr ($_, 0, length "$Enter1 - $Enter2 ") eq "$Enter1 - $Enter2 ");    
	}
	my $CurrentParent = $Path->{$Entry};
	
	if (defined $$CurrentParent[0]){
		push @Path, [$Enter1, $Enter2], $CurrentParent;
		until($$CurrentParent[0] == $Exit1 && $$CurrentParent[1] == $Exit2){
			push @Path, $Path -> {"$$CurrentParent[0] - $$CurrentParent[1] : $$CurrentParent[2]"};
			$CurrentParent = $Path -> {"$$CurrentParent[0] - $$CurrentParent[1] : $$CurrentParent[2]"};
		}
	}
	return \@Path;
}

sub FindThePath{
	my $Labyrinth = shift;
	my (%Path, @Result);
	my @Labyrinth = @{$Labyrinth->{labyrinth}};
	my $Rows = scalar (@Labyrinth);
	my $Columns = scalar (@{$Labyrinth[0]});
	my @dx = (1, -1, 0, 0);
	my @dy = (0, 0, -1, 1);

	push @Result, [$Labyrinth->{exit1}, $Labyrinth->{exit2}, $Labyrinth->{bombs}];
	for my $i (@Result){
		last if ($$i[0] ==  $Labyrinth->{enter1} && $$i[1] ==  $Labyrinth->{enter2});
		
		my $CurrBombs = $$i[2];
		for (my $j = 0; $j<4; ++$j){
			my $x = $$i[0] + $dx[$j];
			my $y = $$i[1] + $dy[$j];
			
			if ($x < $Rows && $y < $Columns && $x >= 0 && $y >= 0){ 
				unless($x == $Labyrinth->{exit1} && $y ==$Labyrinth->{exit2}){
					if ($Labyrinth[$x][$y] == 0 || ($Labyrinth[$x][$y] == 1 && $CurrBombs > 0)){
						my $Bombs = $CurrBombs;
						$Bombs = $CurrBombs-1 if ($Labyrinth[$x][$y] == 1);
					
						unless (defined ($Path {"$x - $y : $Bombs"})){
							$Path {"$x - $y : $Bombs"} = $i;
							push @Result, [$x, $y, $Bombs];
						}
					}
				}
			}
		}
	}	
	return \%Path;
}
1;
