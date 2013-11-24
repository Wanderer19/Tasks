package Sorts1; 
require Exporter;             

@ISA = qw(Exporter); 
@EXPORT = qw(less more bubble_sort select_sort bubble_sort insert_sort pyramid_sort quick_sort shell_sort merge_sort function_sort);
	 
    sub less{
        my ($a,$b) = @_;
         
		return 1 if ( $a<$b );
        return 0;
    }
     
	sub more{
	    my ($a,$b) = @_;

		return 1 if ( $a>$b );
        return 0;
    }
	 
	 sub select_sort{
        my ($aa,$locale_comparator,$data) = @_;
         
		unless ( defined($locale_comparator) ){
			$locale_comparator=\&less;
		}
         
		my @a = @$aa;
        my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);

		for ( my $i=0 ;$i<$n; $i++ ){
            my $min = $a[$i];
            my $k = $i;

			for ( my $j=$i+1 ;$j<$n; $j++ ){
                $comparisons++;
                if ( &{$locale_comparator}($a[$j],$min) ){
                    $min = $a[$j];
                    $k = $j;
                }
            }
            $comparisons++;
            
			if ( &{$locale_comparator}($min,$a[$i]) ){
			    $swap++;
                ($a[$i],$a[$k]) = ($a[$k],$a[$i]);
            }
        }
         
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
	     
		return \@a;
    }

	sub bubble_sort{
        my ($aa,$locale_comparator,$data) = @_;
         
		unless ( defined($locale_comparator) ){
			$locale_comparator = \&less;
		}	 
		 
		my @a = @$aa;
	    my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);
 
		for ( my $i = 1 ;$i < $n; $i++ ){
            for ( my $j = 0 ;$j < $n-1; $j++ ){
			    $comparisons++;
				 
		        if ( &{$locale_comparator}($a[$j+1],$a[$j]) ){
				    $swap++;
				    ($a[$j], $a[$j+1]) = ($a[$j+1],$a[$j]);
				}
            }
		}
		 
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
		 	
        return \@a;
    }

    sub insert_sort{
        my ($aa,$locale_comparator,$data) = @_;
         
		unless ( defined($locale_comparator) ){
			$locale_comparator = \&less;
		}

		my @a = @$aa;
        my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);
         
		for ( my $i=1 ;$i<$n; $i++ ){
		    my $r=$a[$i];
            my $j=$i-1;                                       
            my $p=1;                   

		    while ( $j>=0 && $p ){    
                $comparisons++;		
                 
				if ( &{$locale_comparator}($r,$a[$j]) ){
				    $a[$j+1]=$a[$j];
                    $swap++;				 
				    $j--;
			    }       
                else {
			        $p=0;
			    }                              
            }
         
		    $swap++;
		    $a[$j+1]=$r;                                     
        }
         
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
         
		return \@a;
    }

     
	sub heapify{
        my ($pos, $n,$arr,$comparisons,$swap,$locale_comparator) = @_;
     
	    while ( 2 * $pos + 1 < $n ){
            my $t = 2 * $pos +1;
             
			if ( 2 * $pos + 2 < $n ){
			    $$comparisons++;
			     
				unless ( &{$locale_comparator}($$arr[2 * $pos + 2] , $$arr[$t]) ){
                    $t = 2 * $pos + 2;
                }
			}
		 
		    $$comparisons++;
         
		    if ( &{$locale_comparator}($$arr[$pos],$$arr[$t]) ){
		        $$swap++;
                ($$arr[$pos],$$arr[$t]) = ($$arr[$t],$$arr[$pos]);
                $pos = $t;
            } 
            else {
			    last;
		    }
        }
    }

	 sub pyramid_sort{
         my ($aa,$locale_comparator,$data) = @_;
         
		unless( defined($locale_comparator) ){
			$locale_comparator=\&less;
		}
         
	    my @arr = @$aa;
        my $n  =scalar(@arr);
        my ($comparisons,$swap) = (0,0);

		for ( my $i = $n - 1 ;$i >= 0; $i-- ){
            heapify($i, $n,\@arr,\$comparisons,\$swap,$locale_comparator);
        }
     
	    while ( $n>0 ){
	        $swap++;
            ($arr[0],$arr[$n-1]) = ($arr[$n-1],$arr[0]);
            $n--;
             
			heapify(0,$n,\@arr,\$comparisons,\$swap,$locale_comparator);
        }

        $data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
		 
		return \@arr;
	}

	 sub Hoare{
        my($a,$l,$r,$comparisons,$swap,$locale_comparator) = @_;

        my $sr=int( ($l+$r)/2 );
        my $x=$$a[$sr];
        my ($i,$j)=($l,$r);

		while ( $i<$j ){
            while ( &{$locale_comparator}($$a[$i],$x) ){
			    $i++;
				$$comparisons++;
			}
             
			while ( &{$locale_comparator}($x,$$a[$j]) ){
			    $j--;
				$$comparisons++
			}
         
		    $$comparisons+=2;
         
		    if ( $i<=$j ){
		        $$swap++;
                ($$a[$i],$$a[$j]) = ($$a[$j],$$a[$i]);
                $i++;
				$j--;
            }
        }

		if ( $l<$j ){
		    Hoare($a,$l,$j,$comparisons,$swap,$locale_comparator);
        }
         
		if ( $i<$r ){
            Hoare($a,$i,$r,$comparisons,$swap,$locale_comparator);
        }
	}

	sub quick_sort{
        my ($aa,$locale_comparator,$data)=@_;
        
		unless( defined($locale_comparator) ){
			$locale_comparator=\&less;
		}
		
		my @a = @$aa;
        my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);
         
		Hoare(\@a,0,$n-1,\$comparisons,\$swap,$locale_comparator);
         
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
		 
		return \@a;
	}

	sub shell_sort{
        my ($aa,$locale_comparator,$data) = @_;
         
		unless( defined($locale_comparator) ){
			$locale_comparator=\&less;
		}

		my @a = @$aa;
        my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);
       
		for ( my $k=int($n/2) ;$k>0; $k=int($k/2) ){
            for ( 0..$#a-$k ){
                $j=$_;
                $comparisons++;
				 
				while ($j>=0)
				{
					$comparisons++;
					last unless (&{$locale_comparator}($a[$j+$k],$a[$j]));
					($a[$j],$a[$j+$k]) = ($a[$j+$k],$a[$j]);
					$swap++;
					$j--;
					
				}
			}
        }
		 
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;	
         
		return\@a;
	}

	 
    sub merge {
        my ($a,$l,$r,$comparisons,$swap,$locale_comparator)=@_;
   
        return  if ( $r == $l );
        
		if ( $r - $l == 1 ){ 
		    $$comparisons++;
			 
			if ( &{$locale_comparator}($$a[$r],$$a[$l]) ){
			    ($$a[$r], $$a[$l]) = ($$a[$l], $$a[$r]);
			     $$swap++;
			}
            
			return;
        }
    
	    my $m = int( ($r + $l)/2 );
     
	    merge($a,$l, $m,$comparisons,$swap,$locale_comparator);
        merge($a,$m + 1, $r,$comparisons,$swap,$locale_comparator);
    
        my @buf;
    
	    my $xl = $l;
        my $xr = $m + 1;
        my $cur = 0;
     
	    while ( $r - $l + 1 != $cur ){
            if ( $xl > $m ){
		        $buf[$cur++] = $$a[$xr++];
			    $$swap++;
		    } 
            elsif ( $xr > $r ){
		        $buf[$cur++] = $$a[$xl++];
				$$swap++;
		    }
            elsif ( &{$locale_comparator}($$a[$xr],$$a[$xl]) ){
			    $$comparisons++;
			    $buf[$cur++] = $$a[$xr++];
				$$swap++;
		    }
            else {
			    $$comparisons++;
			    $buf[$cur++] = $$a[$xl++];
				$$swap++;
		    }
        }
    
	    for ( my $i = 0 ;$i < $cur; $i++ ){
	        $$a[$i + $l] = $buf[$i];
		}
    }
     
	 sub merge_sort{
        my ($aa,$locale_comparator,$data) = @_;
         
		unless( defined($locale_comparator) ){
			$locale_comparator = \&less;
		}
         
		my @a = @$aa;
        my $n = scalar(@a);
        my ($comparisons,$swap) = (0,0);
		 
		merge(\@a,0,$#a,\$comparisons,\$swap,$locale_comparator);
		 
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
		 
		return \@a;
	}
	 
	sub Sort{    
	    my ($comparisons,$swap,$locale_comparator) = @_;
	    $$comparisons++;
		 
        if ( &{$locale_comparator}($a,$b) ){
		    $$swap++;
			return -1;
		}
        elsif ( $a==$b ){
		    $$comparisons++;
		    return 0;
		}
        elsif ( &{$locale_comparator}($b,$a) ){
		    $$comparisons+=2;
			return 1;
		}
    }
	
	sub function_sort{
	    my ($aa,$locale_comparator,$data) = @_;
		  
		unless( defined($locale_comparator) ){
			$locale_comparator=\&less;
		}
		  
		my ($comparisons,$swap) = (0,0);
		my @a = @$aa;
		  
		@a = sort {Sort(\$comparisons,\$swap,$locale_comparator)} @a;
		 
		$data->{comparisons} = $comparisons;
		$data->{swap} = $swap;
		  
		return \@a;
	}
1;