package Table; 
require Exporter;  
use Time::HiRes qw(gettimeofday);           
use Sorts1;

@ISA = qw(Exporter);           
@EXPORT = qw(table stability random);   

    sub table{
		my ($sorts,$n,$n1,$step)=@_;
		my (%data,@mass,@nn);
	    my $n0=$n;
		  
        @var=([1..100],[reverse(1..100)],[0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1],[(1)x100]);
        push @mass,@var;		  
		 
		while ( $n0<=$n1 ){
		    my $array=random($n0);
			push @mass,$array;
			$n0*=$step;
		}
         
	    my @z=('1..100','100..1','01010101','(1)x100');
        push @nn,@z;		 

        while ( $n<=$n1 ){
		    push @nn,$n;
			$n*=$step;
	    }
         
		my $i=0;
		my $j=0;
		
		for my $x ( @$sorts ){
		    for my $array ( @mass ){
			    $n0=$nn[$i];
			    my $current_sorting=\&$x;
		        my ($comparisons,$swap)=(0,0);
			     
				if ( ((scalar(@$array)>=10000)) && ($j<=2) ){
				    $table{"$n0"}{"$x"}{swaps}='-';
				    $table{"$n0"}{"$x"}{comparisons}='-';
				    $table{"$n0"}{"$x"}{time}='-';
				    next;
				}
				 
				my $before = gettimeofday;
				my($new_array)=&{$current_sorting}($array,\&less,\%data);
			    my $after=gettimeofday;
				my $time=$after-$before;
				
				$table{"$n0"}{"$x"}{time}=$time;
				$table{"$n0"}{"$x"}{swaps}=$data{swap};
				$table{"$n0"}{"$x"}{comparisons}=$data{comparisons};
				 
				$i++;
		    }	
			$j++;
			$i=0;
		}
		 
		for  $x ( @$sorts ){
		    if ( stability(\&$x) ){
			    $table{"$x"}{stability}='yes';
			}
			else{
			    $table{"$x"}{stability}='no';
			}
		}
		return (\%table,\@nn);
    }
	
	sub stability{
	    my $current_sorting=shift;
		my $b=['1a','1b','2c','1d','2d'];
		my $a= &{$current_sorting}($b);
		 
		for ( my $i=0 ;$i<scalar(@$a)-1; $i++ ){
            return 0   if ( $$a[$i] gt $$a[$i+1] );
        }
        return 1;
    }		 
	 
	sub random{    
        my $n=shift;
        my @a;
         
		for ( my $i=0 ; $i<$n ; $i++ ){
		    $a[$i]=int(rand(1000));
	    }
        return \@a;
    }
1;